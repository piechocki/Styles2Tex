# Styles2Tex

This project contains an Add-in for Microsoft Word that helps you to convert your document into latex code. The output is independent from the latex template you like to use and so it only provides basic formattings like headlines, paragraphs, listing and numbering etc and further technical functionalities that support your workflow from Word to latex compatible code.
The implementation is based on the built-in styles of Word, i. e. if you already use the standard template without manual changes at the format of your paragraphs, this Add-in can be applied on your Word file straightly.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for productive purposes.

### Prerequisites

You need Windows as your operating system with any version of Word installed on it. The .NET framework is required but typically comes out of the box with your Windows installation. The framework that is used currently (4.6.1) is included in Windows 10 update of November 2018 (release 394254). All higher versions will fit as well.

You can find the release of your system by browsing to the following entry of the registry (command "regedit"):

```
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full
```

### Installing

Unfortunately you can't find this Add-in in the Office Store of Microsoft where you can get many extensions for Word. But the good news is, that installation of an external Word Add-in is very simple anyway. Just download the latest compiled version that is located in the folder "Installer" as a zip file. Unzip the file and double click the file "setup". Confirm the upcoming dialog whether you like to install the Add-in although it is from an unknown publisher. If the installation was successful, you should see the following message:

Furthermore when you start Word the next time, you can recognize the "Styles2Tex" group on the ribbon tab "Add-ins".

## Authors

* **M. Piechocki** - *Initial work* - [piechocki](https://github.com/piechocki)

See also the list of [contributors](https://github.com/piechocki/InvarianceHypothesis/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Rights

* Ribbon buttons made by [Icons8](https://icons8.com/)
* Logo made by [Freepik](https://www.flaticon.com/authors/freepik) from flaticon.com
