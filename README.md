# KarlsonMod
A Mod for Karlson (Currently Windows only and very unfinished!)

### What can it do?
Currently, you can load custom levels (kind of..) and remove all the enemies.  
If you have any ideas, please give them to me using the Issues tab. Be sure to label them as "Enhancement"!

### Compiling
You need a copy of [Karlson](https://danidev.itch.io/karlson) and Visual Studio 2019.
I think you need to fix a few References, but then you should be able to just build it normally.

### Running
You need the [SharpMonoInjector (Console)](https://github.com/warbler/SharpMonoInjector/releases) to inject, since the GUI version doesn't work for some random reason.
Put the SharpMonoInjector.dll and smi.exe in the directory, where you just built the DLL.
Go into a cmd, into the directory and run this:
`smi inject -p Karlson -a KarlsonMod.dll -n KarlsonMod -c Loader -m Init`

If everything went right, there should now be another console window for logging purposes.
You should also be able to see the text "KarlsonMod" along with a few buttons in the game.
![screenshot](https://i.imgur.com/8yrS5v5.png)

## Contributing
Please consider helping this Mod get better, since I'm just a single "programmer" that doesn't know much about C#.  
Please create some pull requests, edit the wiki or anything you can do to make the mod better. Thanks.

## FAQ
### How do I load custom levels?
See [Custom Levels](https://github.com/zImPatrick/KarlsonMod/wiki/Custom-Levels) in the wiki
