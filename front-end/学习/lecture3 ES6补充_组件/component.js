var template = `<div>
    <p>年龄 ： {{age}}</p>
    <p>姓名 : {{name}}</p>
</div>`;

//  <user-info name='周子龙' age=‘19'> </user-info>

export default {
    // 组件的属性，在html标签中可以传递进来
    // 组件内部的属性只允许上部分向下传递
    // 组件不能更改自己的属性的！
    props:["name", "age"],


    // 这里一般表示组件内部的数据
    // 使用data函数是为了隔离不同的组件之间的数据
    // data存在于组件内部的数据，不能被别人使用，是组件内部的东西，自己可以修改
    data(){
        return {
            name_data: "肖奇是啥子",
            age_data: 19,
        }
    },
    template,
};