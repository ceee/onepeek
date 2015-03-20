
## query for windows phone store cultures

1. Go to http://www.windowsphone.com/en-us/markets

2. Code:

    var cultures = [];
    $('.marketsLink:not(:empty)').each(function()
    {
      var culture = {
        id: this.href.split('/')[this.href.split('/').length - 1],
        uri: this.href,
      };
      var isInversed = this.title.indexOf('(') === 0;
      var parts = this.title.split(isInversed ? ')' : '(');

      culture.country = parts[isInversed ? 1: 0].trim();
      culture.language = parts[isInversed ? 0 : 1].replace((isInversed ? '(' : ')'), '').trim();
  
      cultures.push(culture); 
    });
    var output = JSON.stringify(cultures);

3. Output is copied to `cultures-windowsphone.json`