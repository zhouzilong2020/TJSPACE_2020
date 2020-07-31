// 默认导出 { default: fn }
export default function sum(a,b){
    return a+b;
}

// 具名导出 （普通导出）{ double: fn }
export function double(a) {
    return a * 2;
}

export var a = 3;

//导出一个对象：{ default: fn, double : fn, n :3}