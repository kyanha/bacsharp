// WinSockWrap.h
// A DLL Wrapper for WinSock

extern "C" {
  __declspec(dllexport) int WinSockStartUp();
}

extern "C" {
  __declspec(dllexport) int WinSockSendTo(char* bytes, int count, unsigned long ipaddr);
}

extern "C" {
  __declspec(dllexport) int WinSockRecvReady();
}

extern "C" {
  __declspec(dllexport) int WinSockRecvFrom(char* bytes, int* count, unsigned long* ipaddr);
}

extern "C" {
  __declspec(dllexport) int WinSockShutDown();
}

extern "C" {
  __declspec(dllexport) int WinSockLastError();
}

