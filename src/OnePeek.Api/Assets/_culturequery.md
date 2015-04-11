
## query for windows phone store cultures

1) Go to http://www.windowsphone.com/en-us/markets

2) Code:

    var cultures = [];
    $('.marketsLink:not(:empty)').each(function()
    {
      var isInversed = this.title.indexOf('(') === 0;
      var parts = this.title.split(isInversed ? ')' : '(');
    
      cultures.push({
        id: this.href.split('/')[this.href.split('/').length - 1],
        uri: this.href,
        name: this.title,
        country: parts[isInversed ? 1: 0].trim(),
        language: parts[isInversed ? 0 : 1].replace((isInversed ? '(' : ')'), '').trim()
      }); 
    });
    var output = JSON.stringify(cultures);

3) Output is copied to `cultures-windowsphone.json`

## query for windows store cultures

_Is this the http://windows.microsoft.com/en-us/windows/worldwide full list? ..._

1) Go to http://windows.microsoft.com/en-us/windows/worldwide

2) Code:

    var cultures = [];
    $('.topic_body .navigationLink[href$="windows/home"]').each(function()
    {
      var parts = this.innerText.split(' — ');
    
      cultures.push({
        id: this.href.split('/')[3],
        uri: this.href,
        name: this.innerText,
        country: parts[0].trim(),
        language: parts[1].trim()
      }); 
    });
    var output = JSON.stringify(cultures);

4) Output is copied to `cultures-windows.json`

5) Create StoreCultureType enum with:

    var enumlist = "";
    $.each(cultures, function (i, val)
    {
      enumlist += '\n/// <summary>\n' +
        '/// ' + val.country + ' (' + val.language + ')\n' +
        '/// </summary>\n' +
        '[Display(Name = "' + val.country + ' (' + val.language + ')")]\n' +
        val.id.replace('-', '_').replace('-', '_').toUpperCase() + ',';
    });