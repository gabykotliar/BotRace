# Build the solution
echo -e "\e[32mChecking application build\e[0m"
C:\\WINDOWS\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe src/Issuance.sln /verbosity:q /clp:ErrorsOnly

if [ $? -eq 1 ]
  then
    echo -e "\e[41mThe commit was cancelled due to build problems in the solution\e[49m" 
	exit 1
  else
	echo -e "\e[33mBuild succeeded, continue committing...\e[0m"
	echo
fi

# Run stylecop
echo -e "\e[32mChecking Stylecop violations\e[0m"
C:\\WINDOWS\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe src/MsBuild/StyleCopHook.proj /clp:"parameters;NoSummary"

if [ $? -eq 1 ]
  then
    echo -e "\e[41mThe commit was cancelled due to Stylecop violations\e[49m"
	exit 1
  else
    echo -e "\e[33mNo Stylecop violations, continue committing...\e[0m"	
	echo
fi