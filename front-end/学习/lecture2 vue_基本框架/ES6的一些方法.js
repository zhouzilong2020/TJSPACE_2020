//速写属性
var name = "abc"
var obj = {
    name, //实际上等于 name : name
}

//速写方法
var obj2 = {
    aFunction(){
        console.log('asd');
    }
}

//箭头函数：会绑定this！！
var obj3 = {
    aFunction(){
        setInterval( () =>{
            console.log(this);  //  这个this绑定的是对象的this
        }, 1000)
    }
}

//匿名函数都可以使用尖头函数的格式
//仅有一行代码还可以省略{}
var func = (a, b) =>  a + b;

// console.log(func(1,2));

//