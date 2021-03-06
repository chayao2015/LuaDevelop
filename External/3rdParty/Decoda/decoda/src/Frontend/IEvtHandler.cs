/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace Decoda {

public class IEvtHandler : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal IEvtHandler(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IEvtHandler obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~IEvtHandler() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          DecodaPINVOKE.delete_IEvtHandler(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual void AddPendingEvent(DebugEvent e) {
    DecodaPINVOKE.IEvtHandler_AddPendingEvent(swigCPtr, DebugEvent.getCPtr(e));
    if (DecodaPINVOKE.SWIGPendingException.Pending) throw DecodaPINVOKE.SWIGPendingException.Retrieve();
  }

  public IEvtHandler() : this(DecodaPINVOKE.new_IEvtHandler(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("AddPendingEvent", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateIEvtHandler_0(SwigDirectorAddPendingEvent);
    DecodaPINVOKE.IEvtHandler_director_connect(swigCPtr, swigDelegate0);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(IEvtHandler));
    return hasDerivedMethod;
  }

  private void SwigDirectorAddPendingEvent(global::System.IntPtr e) {
    AddPendingEvent(new DebugEvent(e, false));
  }

  public delegate void SwigDelegateIEvtHandler_0(global::System.IntPtr e);

  private SwigDelegateIEvtHandler_0 swigDelegate0;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(DebugEvent) };
}

}
