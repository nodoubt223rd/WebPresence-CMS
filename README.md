# Web Presence CMS

http://www.nodoubt223rd.com

> Compile Sass to CSS

## Getting Started
This plugin requires Grunt `>=0.4.0`

If you haven't used [Grunt](http://gruntjs.com/) before, be sure to check out the [Getting Started](http://gruntjs.com/getting-started) guide, as it explains how to create a [Gruntfile](http://gruntjs.com/sample-gruntfile) as well as install and use Grunt plugins. Once you're familiar with that process, you may install this plugin with this command:

```shell
npm install grunt-contrib-sass --save-dev
```

Once the plugin has been installed, it may be enabled inside your Gruntfile with this line of JavaScript:

```js
grunt.loadNpmTasks('grunt-contrib-sass');
```

## Sass task
_Run this task with the `grunt sass` command._

[Sass](http://sass-lang.com) is a preprocessor that adds nested rules, variables, mixins and functions, selector inheritance, and more to CSS. Sass files compile into well-formatted, standard CSS to use in your site or application.

This task requires you to have [Ruby](http://www.ruby-lang.org/en/downloads/) and [Sass](http://sass-lang.com/download.html) installed. If you're on OS X or Linux you probably already have Ruby installed; test with `ruby -v` in your terminal. When you've confirmed you have Ruby installed, run `gem install sass` to install Sass.

Note: Files that begin with "_" are ignored even if they match the globbing pattern. This is done to match the expected [Sass partial behaviour](http://sass-lang.com/documentation/file.SASS_REFERENCE.html#partials).


## Structure
- `WebPresence` - Contains all web files. css files can be found in the content folder, scripts in the scripts folder.
- `WebPresence.Common` - Contains constants files, and common functionality.
- `WebPresence.Core` - Contains core functionality, used by the dashboard.
- `WebPresence.Data` - Data layer of the CMS.
- `WebPresence.Domain` - Contains all DTO related to WebPresence.Data.
- `WebPresence.Presentation` - Contains all presentation objects.
- `WebPresence.Service` - Contains the business layer of the CMS.

*All libraries are contained in the packages folder at the root level of each project*