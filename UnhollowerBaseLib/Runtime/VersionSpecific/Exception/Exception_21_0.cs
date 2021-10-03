﻿using System;
using System.Runtime.InteropServices;

namespace UnhollowerBaseLib.Runtime.VersionSpecific.Exception
{
    [ApplicableToUnityVersionsSince("5.3.5")]
    public unsafe class NativeExceptionStructHandler_21_0 : INativeExceptionStructHandler
    {
        public INativeExceptionStruct CreateNewExceptionStruct()
        {
            var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Il2CppException_21_0>());

            *(Il2CppException_21_0*)pointer = default;

            return new NativeExceptionStruct(pointer);
        }

        public INativeExceptionStruct Wrap(Il2CppException* exceptionPointer)
        {
            if ((IntPtr)exceptionPointer == IntPtr.Zero) return null;
            else return new NativeExceptionStruct((IntPtr)exceptionPointer);
        }

#if DEBUG
        public string GetName() => "NativeExceptionStructHandler_21_0";
#endif

        [StructLayout(LayoutKind.Sequential)]
        internal struct Il2CppException_21_0
        {
            public Il2CppObject @object;
            public IntPtr /* Il2CppArray* */ trace_ips;
            public Il2CppException* inner_ex;
            public IntPtr /* Il2CppString* */ message;
            public IntPtr /* Il2CppString* */ help_link;
            public IntPtr /* Il2CppString* */ class_name;
            public IntPtr /* Il2CppString* */ stack_trace;
            public IntPtr /* Il2CppString* */ remote_stack_trace;
            public int remote_stack_index;
            public int hresult;
            public IntPtr /* Il2CppString* */ source;
            public IntPtr /* Il2CppObject* */ _data;
        }

        internal class NativeExceptionStruct : INativeExceptionStruct
        {
            public NativeExceptionStruct(IntPtr pointer)
            {
                Pointer = pointer;
            }

            public IntPtr Pointer { get; }

            public Il2CppException* ExceptionPointer => (Il2CppException*)Pointer;

            private Il2CppException_21_0* NativeException => (Il2CppException_21_0*)Pointer;

            public ref Il2CppException* InnerException => ref NativeException->inner_ex;

            public INativeExceptionStruct InnerExceptionWrapped
            {
                get
                {
                    IntPtr ptr = (IntPtr)NativeException->inner_ex;
                    if (ptr == IntPtr.Zero) return null;
                    else return new NativeExceptionStruct(ptr);
                }
            }

            public ref IntPtr Message => ref NativeException->message;

            public ref IntPtr HelpLink => ref NativeException->help_link;

            public ref IntPtr ClassName => ref NativeException->class_name;

            public ref IntPtr StackTrace => ref NativeException->stack_trace;

            public ref IntPtr RemoteStackTrace => ref NativeException->remote_stack_trace;
        }
    }
}
