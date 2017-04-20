# wmc
Weka May Cry is a toolset that does elementary big data operations.

## Usage
WMC is executed using the command line. Here are some commands below:

#### Slant Calculator
You will need a wordlist CSV with the headers/columns &Good, &Topical, &Bad. Down the columns, list out the respective keywords for that category. You will also need a directory of corpuses in text files.
```
wmc slant <input type flag> <input directory/file> -WL <input wordlist file>
example: wmc slant -dir C:/path/to/directory C:/path/to/wordlist.csv
```
To interpret the results, the k-slant score is the slant that the corpus leans against. Scores are out of 100. A positive score means the corpus leans more towards the words defined as &Good in the wordlist, and vice versa for &Bad words.

This list will be updated as more functions are added.

##FAQ

## Contributing
1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History
Its name is a triple play on words, namely the Devil May Cry franchise, the distinctive call of the weka bird itself, and a homage to the frustrations some classmates experienced trying to use a certain application on their project.

## License
>Copyright 2017 Kevin Vinh Nguyen
>Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
>The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
>THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


