set targdir=%1

rmdir /s /q \tmp\thesis
mkdir \tmp\thesis
svn checkout http://10.0.0.3/svn/masters/trunk/thesis \tmp\thesis\thesis
svn checkout http://10.0.0.3/svn/masters/trunk/tools \tmp\thesis\tools

pushd

cd \tmp\thesis\tools\Transform
make

cd ..\..\thesis\

make html
cmd /c make pdf

mkdir %targdir%
copy /y html\thesis.html %targdir%
copy /y pdf\thesis.pdf %targdir%

date /t >> index.html
time /t >> index.html
echo '</p> </body></html>' >> index.html
copy /y index.html %targdir%

cd ..

copy /y tools\styles.css %targdir%

popd
