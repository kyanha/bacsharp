﻿/* COPYRIGHT
 -------------------------------------------
 Copyright (C) 2013 Plus 1 Micro, Inc.

 This program is free software; you can redistribute it and/or
 modify it under the terms of the GNU General Public License
 as published by the Free Software Foundation; either version 2
 of the License, or (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program; if not, write to:
 The Free Software Foundation, Inc.
 59 Temple Place - Suite 330
 Boston, MA  02111-1307, USA.

 As a special exception, if other files instantiate templates or
 use macros or inline functions from this file, or you compile
 this file and link it with other works to produce a work based
 on this file, this file does not by itself cause the resulting
 work to be covered by the GNU General Public License. However
 the source code for this file must still be made available in
 accordance with section (3) of the GNU General Public License.

 This exception does not invalidate any other reasons why a work
 based on this file might be covered by the GNU General Public
 License.
 -------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ini;
using BACnet;

namespace BACnetTest
{
  public partial class MainForm : Form
  {

    public static MainForm Self;

    BACnetStack stack;
    string server;
    
    public MainForm()
    {
      InitializeComponent();
      Self = this;  // Works only if there is only one mainform

      string appini = Application.StartupPath + @"\BACnetTest.INI";
      if (File.Exists(appini))
      {
        IniFile ini = new IniFile(appini);
        server = ini.IniReadValue("Network", "Server");
      }

      //if (server == "") server = "198.168.92.68";

      ServerText.Text = server;

      GetObjectsBtn.Enabled = false;
      ReadPresentValueBtn.Enabled = false;
      TestBinaryOnBtn.Enabled = false;
      TestBinaryOffBtn.Enabled = false;
    }

    public void SetBroadcastLabel(string s)
    {
      BroadcastLabel.Text = s;
    }

    private void GetDevicesBtn_Click(object sender, EventArgs e)
    {
      // Create the BACnet Stack, and populate the Devices List
      try
      {
        if (ServerText.Text != server)
        {
          server = ServerText.Text;
          string appini = Application.StartupPath + @"\BACnetTest.INI";
          IniFile ini = new IniFile(appini);
          ini.IniWriteValue("Network", "Server", server);
        }

        stack = new BACnetStack(server);
        stack.GetDevices(500);

        DeviceList.Items.Clear();
        foreach (Device dev in BACnetData.Devices)
        {
          DeviceList.Items.Add(
            //dev.VendorID.ToString() + ", " + 
            dev.Network.ToString() + ", " +
            dev.Instance.ToString());
        }
        ServerText.Enabled = false;
        GetDevicesBtn.Enabled = false;
        GetObjectsBtn.Enabled = true;
      }
      catch
      {
        MessageBox.Show("Could not initialize");
      }
    }

    private void TestReadPropBtn_Click(object sender, EventArgs e)
    {
      TestReadLabel.Text = "...";

      Property prop = new Property();
      prop.Tag = BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_CHARACTER_STRING;
      if (stack.SendReadProperty(
        BACnetData.DeviceIndex,
        BACnetData.Devices[BACnetData.DeviceIndex].Instance,
        -1,
        BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_DEVICE,
        BACnetEnums.BACNET_PROPERTY_ID.PROP_SERIAL_NUMBER,
        //BACnetEnums.BACNET_PROPERTY_ID.PROP_APPLICATION_SOFTWARE_VERSION,
        //BACnetEnums.BACNET_PROPERTY_ID.PROP_MAX_MASTER,
        //BACnetEnums.BACNET_PROPERTY_ID.PROP_BAUD_RATE,
        prop))
        TestReadLabel.Text = prop.ValueString;
      else
        TestReadLabel.Text = "Read Property Error";
    }

    private void DeviceList_SelectedIndexChanged(object sender, EventArgs e)
    {
      int idx = DeviceList.SelectedIndex;
      if ((idx >= 0) && (idx < BACnetData.Devices.Count()))
      {
        DeviceIDText.Text = BACnetData.Devices[idx].Instance.ToString();
        DeviceLabel.Text = BACnetData.Devices[idx].Instance.ToString();
        BACnetData.DeviceIndex = idx;
      }
    }

    private void GetObjectsBtn_Click(object sender, EventArgs e)
    {
      // Read the Device Array
      Property prop = new Property();
      prop.Tag = BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_ENUMERATED;
      if (!stack.SendReadProperty(
        BACnetData.DeviceIndex,
        BACnetData.Devices[BACnetData.DeviceIndex].Instance,
        0, // Array[0] is Object Count
        BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_DEVICE,
        BACnetEnums.BACNET_PROPERTY_ID.PROP_OBJECT_LIST,
        prop))
      {
        ObjectListLabel.Text = "Read Property Object List Error (1)";
        return;
      }

      if (prop.Tag != BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_UNSIGNED_INT)
      {
        ObjectListLabel.Text = "Read Property Object List Error (2)";
        return;
      }

      ObjectListLabel.Text = prop.ValueUInt.ToString() + " objects found";

      int i, tries;
      uint total = prop.ValueUInt;
      ObjectList.Items.Clear();
      if (total > 0) for (i = 1; i <= total; i++)
      {
        // Read through Array[x] up to Object Count
        //PEP Need to try the read again if it times out
        tries = 0;
        while (tries < 5)
        {
          tries++;
          if (stack.SendReadProperty(
            BACnetData.DeviceIndex,
            BACnetData.Devices[BACnetData.DeviceIndex].Instance,
            i, // each array index
            BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_DEVICE,
            BACnetEnums.BACNET_PROPERTY_ID.PROP_OBJECT_LIST,
            prop))
          {
            tries = 5; // Next object
            string s;
            if (prop.Tag != BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_OBJECT_ID)
              tries = 5; // continue;
            switch (prop.ValueObjectType)
            {
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_DEVICE: s = "Device"; break;
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_ANALOG_INPUT: s = "Analog Input"; break;
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_ANALOG_OUTPUT: s = "Analog Output"; break;
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_ANALOG_VALUE: s = "Analog value"; break;
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_BINARY_INPUT: s = "Binary Input"; break;
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_BINARY_OUTPUT: s = "Binary Output"; break;
              case BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_BINARY_VALUE: s = "Binary value"; break;
              default: s = "Other"; break;
            }
            s = s + "  " + prop.ValueObjectInstance.ToString();
            ObjectList.Items.Add(s);
          }
        }
      }
    }

    private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
      int idx = ObjectList.SelectedIndex;
      ReadPresentValueBtn.Enabled = false;
      TestBinaryOnBtn.Enabled = false;
      TestBinaryOffBtn.Enabled = false;
      if (idx >= 0)
      {
        string s = ObjectList.Items[idx].ToString();
        ObjectLabel.Text = s;
        if (s.Length > 13) if (s.Substring(0, 13) == "Binary Output")
        {
          ReadPresentValueBtn.Enabled = true;
          TestBinaryOnBtn.Enabled = true;
          TestBinaryOffBtn.Enabled = true;
        }
      }
    }

    private void ReadPresentValueBtn_Click(object sender, EventArgs e)
    {
      PresentValueLabel.Text = "...";
      int idx = ObjectList.SelectedIndex;
      if (idx >= 0)
      {
        string s = ObjectList.Items[idx].ToString();
        string s1 = s.Substring(15);
        if (s1.Length > 0)
        {
          uint inst = Convert.ToUInt32(s1);
          Property prop = new Property();
          if (!stack.SendReadProperty(
            BACnetData.DeviceIndex,
            inst,
            -1,
            BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_BINARY_OUTPUT,
            BACnetEnums.BACNET_PROPERTY_ID.PROP_PRESENT_VALUE,
            prop))
          {
            PresentValueLabel.Text = "Read Present Value Error (1)";
            return;
          }
          if (prop.Tag != BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_ENUMERATED)
          {
            PresentValueLabel.Text = "Read Present Value Error (2)";
            return;
          }
          if (prop.ValueEnum == 1)
            PresentValueLabel.Text = "Binary Output On";
          else
            PresentValueLabel.Text = "Binary Output Off";
        }
      }
    }

    private void TestBinaryOnBtn_Click(object sender, EventArgs e)
    {
      // Test Binary On
      TestWriteLabel.Text = "...";

      int idx = ObjectList.SelectedIndex;
      if (idx >= 0)
      {
        string s = ObjectList.Items[idx].ToString();
        string s1 = s.Substring(15);
        if (s1.Length > 0)
        {
          uint inst = Convert.ToUInt32(s1);
          Property prop = new Property();
          prop.Tag = BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_ENUMERATED;
          prop.ValueEnum = 1; // Turn it on
          if (stack.SendWriteProperty(
            BACnetData.DeviceIndex,
            inst,
            -1,
            BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_BINARY_OUTPUT,
            BACnetEnums.BACNET_PROPERTY_ID.PROP_PRESENT_VALUE,
            prop, 1))
            TestWriteLabel.Text = "Binary Output On";
          else
            TestWriteLabel.Text = "Binary Output On Error";
        }
      }
    }

    private void TestBinaryOffBtn_Click(object sender, EventArgs e)
    {
      // Test Binary Off
      TestWriteLabel.Text = "...";

      int idx = ObjectList.SelectedIndex;
      if (idx >= 0)
      {
        string s = ObjectList.Items[idx].ToString();
        string s1 = s.Substring(15);
        if (s1.Length > 0)
        {
          uint inst = Convert.ToUInt32(s1);
          Property prop = new Property();
          prop.Tag = BACnetEnums.BACNET_APPLICATION_TAG.BACNET_APPLICATION_TAG_ENUMERATED;
          prop.ValueEnum = 0; // Turn if off
          if (stack.SendWriteProperty(
            BACnetData.DeviceIndex,
            inst,
            -1,
            BACnetEnums.BACNET_OBJECT_TYPE.OBJECT_BINARY_OUTPUT,
            BACnetEnums.BACNET_PROPERTY_ID.PROP_PRESENT_VALUE,
            prop, 1))
            TestWriteLabel.Text = "Binary Output Off";
          else
            TestWriteLabel.Text = "Binary Output Off Error";
        }
      }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (stack != null) stack.Close();
    }

  }

}
