Jekyll front matter supported.

"Front Matter" is a block of YAML text at the begining of each post with variables and settings
that are used to define the post.

---
layout: post

title: This is a blog post title!

permalink: /year/month/day/title

published: true/false

date: yyyy-mm-dd hh:mm:ss +/- TTTT

category: one
categories: [one, two]
categories:
  - one
  - two
  
tag: one
tags: [one, two]
tags:
  - one
  - two

excerpt: "" 
---

If no excerpt is provided the system will auto generate one by using the first paragraph of html <p>to</p>

----------

Supported formats for posts are raw text (.txt), markdown/commonmark (.md/.cm) or html (.htm/.html)

---------

code formating

includes basic code formating including color coding and display of line numbers (default included langages html, javascript, css, c#, vb) using
highlightjs.org

https://highlightjs.org/download/

----------

App_Data folders

/Posts

/Pages

/Collections

/Themes

