build:
	nuget restore
	xbuild StyleCop.Baboon.sln

test: build
	nunit-console StyleCop.Baboon.Tests/bin/Debug/StyleCop.Baboon.Tests.dll

install: build
	mkdir -p /usr/local/opt/StyleCop.Baboon
	cp $(shell pwd)/StyleCop.Baboon/bin/Debug/* /usr/local/opt/StyleCop.Baboon/
	printf '%s\n%s' '#!/bin/bash' 'exec $(shell which mono) /usr/local/opt/StyleCop.Baboon/StyleCop.Baboon.exe "$$@"' > /usr/local/bin/StyleCop.Baboon
	chmod a+x /usr/local/bin/StyleCop.Baboon
