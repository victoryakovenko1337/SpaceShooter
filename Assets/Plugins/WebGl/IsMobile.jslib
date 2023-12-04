var Plugin = {
	IsMobileFromJS: function()
	{
		return Module.SystemInfo.mobile;
	}
};

mergeInto(LibraryManager.library, Plugin);