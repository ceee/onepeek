
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
		country: parts[isInversed ? 1: 0].trim(),
		language: parts[isInversed ? 0 : 1].replace((isInversed ? '(' : ')'), '').trim()
      }); 
    });
    var output = JSON.stringify(cultures);

3) Output is copied to `cultures-windowsphone.json`