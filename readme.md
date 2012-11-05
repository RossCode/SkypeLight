SkypeLight
==========

SkypeLight is an application that allows you to use a [BusyLight UC](http://www.busylight.com/busylight-lync.html) for monitoring Skype calls. As the 
BusyLight does not have a public API yet, only certain functionality is working right now - the light will
show green when not on a call, yellow when ringing, and red when on a call. Sounds are not currently working
at all.

### Setup

SkypeLight uses the Skype API available through the application, so Skype must be running for SkypeLight to
work. When SkypeLight is started, it will attempt to retrieve the call status from Skype. To make this work, 
you must grant access to SkypeLight through Skype. Once done, SkypeLight will work with Skype. This only 
has to be done once, although if you upgrade SkypeLight, Skype will request permission again.

If Skype does not prompt you to allow SkypeLight permission when running SkypeLight, you will need to install
[Skype4COM](http://developer.skype.com/accessories/skype4com) first. 
