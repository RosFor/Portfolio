$(document).ready(function(){
  loadAllItems();
});

function getActiveItem(vendId){
  $('#vendItemNumber').val(vendId);
  activeItem = vendId;
}

function loadAllItems() {
  var formatRows = $('#itemTableDiv');
  formatRows.html('');
  $.ajax({
    type: 'GET',
    url: 'http://vending.us-east-1.elasticbeanstalk.com/items',
    success: function(itemArray){
      $.each(itemArray, function(index, item) {
        let i = index;
        var vendId = (i+1);
        var id = item.id;
        var name = item.name;
        var price = item.price;
        var quantity = item.quantity;

        var content = `<div id ="${vendId}" class="itemTable" actual-Id="${id}" >`;
        content += '<p>' + (i+1) + '</p>';
        content += `<button onclick="getActiveItem(${vendId})">` + name + '</button>';
        content += '<p> $' + price.toFixed(2) + '</p>';
        content += '<p> Quantity Left: ' + quantity + '</p>';
        content+= "</div>";
        formatRows.append(content);
      });
    },
  });
}

var change = 0;
var moneyInserted = 0;
var totalInserted = 0;

var amount = 0;

var dollars = 0;
var quarters = 0;
var dimes = 0;
var nickels = 0;
var activeItem = null;

function addMoney(){
  moneyInserted = ((dollars * 1) + (quarters * 0.25) + (dimes * 0.10) + (nickels * 0.05));
  return moneyInserted;
}

function resetMoney(){
  change = 0;
  moneyInserted = 0;
  totalInserted = 0;
  amount = 0;
  dollars = 0;
  quarters = 0;
  dimes = 0;
   nickels = 0;
   $('#amountInserted').html('$0.00');
}

function calculateTotal(currency){
  if(currency === 'dollar'){
    dollars++;
  }
  if(currency === 'quarter'){
    quarters++;
  }
  if(currency === 'dime'){
    dimes++;
  }
  if(currency === 'nickel'){
    nickels++;
  }
  totalInserted = addMoney();
  totalInserted = Math.round(totalInserted * 100)/100;
  moneyInserted = totalInserted.toLocaleString('en-US', {
  style: 'currency',
  currency: 'USD',
})
  document.getElementById('amountInserted').innerHTML = moneyInserted;
}

function vendItem() {
  $('#changeField').html('-');
  var vendId = document.getElementById('vendItemNumber').value;
  if(activeItem === null)
  {
    $('#messagesField').html("Please make a selection.");
    return;
  };

  var element = document.getElementById(`${vendId}`);
  var id = element.getAttribute('actual-Id');

    $.ajax({
      type:'POST',
      url:'http://vending.us-east-1.elasticbeanstalk.com/money/' + totalInserted + '/item/' + id,
      success: function(event) {
        $('#messagesField').html("THANK YOU!");

        var message = '';
        for(var currency in event){
          var amount = event[currency];
          if(amount > 0)
          {
            message += amount + ' ' + currency + ' ';
          }
        }
      $('#changeField').html(message);
      resetMoney();
      loadAllItems();
      $('#vendItemNumber').val('');
      activeItem = null;
    },
      error: function (e) {
        var message = e.responseJSON.message;
        $('#messagesField').html(message);
      }
    });
}

function resetFormReturnChange(){
  var message = '-';
  activeItem = null;
  $('#vendItemNumber').val('');
  message = '-';
  $('#messagesField').html(message);
  if(dollars === 0 && quarters === 0 && dimes === 0 && nickels === 0){
    $('#changeField').html('-');
    return;
  }
  var quartersReturned = (dollars * 4) + quarters;
  $('#changeField').html(quartersReturned + ' quarters, ' + dimes + ' dimes, ' + nickels + ' nickels');
  resetMoney();
}
