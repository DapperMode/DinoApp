//SIMPLE DEPENDANCY INJECTION EXAMPLE

//declaring the object
var person = function (firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
}



//NO DEPENDANCY INJECTION
function logPerson() {
    var john = new person('John', 'Doe'); //this function is dependant on the variable created within
    console.log(john);
}

logPerson();



//WITH DEPENDANCY INJECTION

function logPerson(person) { // the dependancy is now being passed in or "injected" rather than being constructed in the function itself
    console.log(person);
}

var joe = person('Joe', 'Carlson'); // create the dependancy outside of the function

logPerson(joe); //pass in the dependancy as a function parameter on the function call