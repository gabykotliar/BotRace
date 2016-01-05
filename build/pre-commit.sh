#Verify that no previous stylecop failed files are attempt to commit without adding changes

if [ -f _diff___.txt ]; then
    echo "Verifying the last Commit Attempt"
    echo 
    while read p; do
        fs=$(git diff --cached --name-only -- $p)
        fm=$(git diff --name-only -- $p)
        if [ ! -z "$fs" -a "$fm" == "$fs" ]; then
            echo -e "\e[41mThe commit was cancelled\e[49m"
            echo -e "\e[41mThe file $fs is both staged and not staged for commit\e[49m"
            echo -e '\e[41m   In order to commit you must stage this file (use "git add <file>..." to update what will be committed)\e[49m'
            echo -e '\e[41m     or unstage it (use "git reset HEAD <file>..." to unstage)\e[49m'
            exit 1
        fi
    done < _diff___.txt
    #cat _diff___.txt
fi

git diff --cached --name-only -- *.cs > _diff___.txt

sed -e 's/^src/.../g' _diff___.txt > _to_check.txt

#cat _to_check.txt
#cat _diff___.txt

# Run stylecop over those files which are ready to commit
echo -e "\e[32mChecking Stylecop violations\e[0m"
C:\\WINDOWS\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe src/MsBuild/StyleCopPreCommitHook.proj /verbosity:m /clp:"parameters;NoSummary"

result=$?

rm _to_check.txt

if [ $result -eq 1 ]
  then
    echo -e "\e[41mThe commit was cancelled due to Stylecop violations\e[49m"
    exit 1
  else
    echo -e "\e[33mNo Stylecop violations, continue committing...\e[0m" 
    rm _diff___.txt
    echo
fi