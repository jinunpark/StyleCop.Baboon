# StyleCop.Baboon - StyleCop working anywhere

StyleCop.Baboon helps you to fix [StyleCop](https://github.com/StyleCop/StyleCop) problems without an IDE and from any OS that runs C#.

[![Build Status](https://travis-ci.org/nelsonsar/StyleCop.Baboon.svg?branch=master)](https://travis-ci.org/nelsonsar/StyleCop.Baboon)

## <a name="installation"></a>Installation / Usage

1. Clone this repository

2. Build the solution.

    * On Windows:

        ```sh
        $ nuget restore
        $ msbuild "StyleCop.Baboon.sln"
        ```

    * On Linux and OSX after you have installed [Mono](http://www.mono-project.com/download/):

        ```sh
        $ nuget restore
        $ xbuild "StyleCop.Baboon.sln"
        ```

4. Use your custom StyleCop settings to analyze a file or a directory. This will generate ```StyleCopViolations.xml``` file.

    ```
    $ [mono] StyleCop.Baboon.exe Settings.StyleCop StyleCop.Baboon/Program.cs
    ```

5. Enjoy! Fix StyleCop's complaints and stay on the line to avoid more complaints.

## Global installation of StyleCop.Baboon (Linux only)

1. Follow instructions [here](#installation).

2. On the command line:

    ```sh
    $ mkdir -p /usr/local/opt/StyleCop.Baboon
    $ cp [dir-that-baboon-was-built]/bin/Debug/* /usr/local/opt/StyleCop.Baboon/
    $ printf '%s\n%s' '#!/bin/bash' 'exec $(which mono) /usr/local/opt/StyleCop.Baboon/StyleCop.Baboon.exe "$@"' > /usr/local/bin/StyleCop.Baboon
    $ chmod a+x /usr/local/bin/StyleCop.Baboon
    ```

3. Now ```StyleCop.Baboon``` should be available in your ```$PATH```!

## Using along with Jenkins

This was the motivation to create this project!

Jenkins [Violations plugin](https://wiki.jenkins-ci.org/display/JENKINS/Violations) supports StyleCop and you can use StyleCop.Baboon to generate the xml file that will be used by the plugin.

## Author

Nelson Senna - [https://twitter.com/nelson_senna](https://twitter.com/nelson_senna) - [http://nelsonsar.github.io](http://nelsonsar.github.io)

## License

StyleCop.Baboon is licensed under the MIT License - see the LICENSE file for details
