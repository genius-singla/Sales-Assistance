package md53de16464760ad3b8384fe79c95b7d762;


public class Changepassword
	extends md53de16464760ad3b8384fe79c95b7d762.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("App7.Changepassword, App7", Changepassword.class, __md_methods);
	}


	public Changepassword ()
	{
		super ();
		if (getClass () == Changepassword.class)
			mono.android.TypeManager.Activate ("App7.Changepassword, App7", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}