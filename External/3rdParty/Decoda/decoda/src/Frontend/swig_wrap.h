/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.2
 *
 * This file is not intended to be easily readable and contains a number of
 * coding conventions designed to improve portability and efficiency. Do not make
 * changes to this file unless you know what you are doing--modify the SWIG
 * interface file instead.
 * ----------------------------------------------------------------------------- */

#ifndef SWIG_Decoda_WRAP_H_
#define SWIG_Decoda_WRAP_H_

class SwigDirector_IEvtHandler : public IEvtHandler, public Swig::Director {

public:
    SwigDirector_IEvtHandler();
    virtual ~SwigDirector_IEvtHandler();
    virtual void AddPendingEvent(DebugEvent const &e);

    typedef void (SWIGSTDCALL* SWIG_Callback0_t)(void *);
    void swig_connect_director(SWIG_Callback0_t callbackAddPendingEvent);

private:
    SWIG_Callback0_t swig_callbackAddPendingEvent;
    void swig_init_callbacks();
};


#endif
