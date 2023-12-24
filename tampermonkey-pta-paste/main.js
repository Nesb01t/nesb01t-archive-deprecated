// ==UserScript==
// @name         pta-paste
// @namespace    yurina.cafe
// @version      1.0
// @description  add a paste button upon your problem editor
// @author       nesb01t
// @match        https://pintia.cn/*
// @grant        none
// ==/UserScript==

(function async() {
  'use strict';

  // add button
  const index = setInterval(function () {
    addButton();
  }, 10);
  var addButton = async () => {
    var elems = document.getElementsByClassName("flex grow items-center");
    if (elems.length > 0) {
      clearInterval(index);
      setTimeout(function () {
        var btn = document.createElement('a');
        btn.textContent = 'PASTE';
        btn.style.padding = '10px';
        btn.addEventListener('click', async () => {
          var item = document.getElementsByClassName("cm-content")[0];
          const text = await navigator.clipboard.readText();
          item.textContent = text;
        })

        elems[0].appendChild(btn);
      }, 100)
    }
    console.log(12);
  }
})();