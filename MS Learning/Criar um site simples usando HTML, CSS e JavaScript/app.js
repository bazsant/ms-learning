'use strict';

const today = new Date();
const formatDate = today.toDateString();
const selectElement = document.getElementById('date');
selectElement.innerHTML = formatDate;


