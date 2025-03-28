…or create a new repository on the command line
echo "# datingapp" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/MeerSam/datingapp.git
git push -u origin main
