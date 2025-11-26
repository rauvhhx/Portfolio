
const style = document.createElement("style");
style.textContent = `
    body {
        background: #5f9ea0;
        font-family: Arial, sans-serif;
    }

    .container {
        width: 450px;
        margin: 80px auto;
        text-align: center;
    }

    input {
        width: 90%;
        padding: 10px;
        margin: 12px 0;
        border-radius: 10px;
        border: none;
        font-size: 17px;
    }

    #result {
        background: #fff7c4;
        font-weight: bold;
    }

    button {
        width: 100px;
        padding: 10px;
        margin: 10px;
        cursor: pointer;
        border-radius: 8px;
        border: 1px solid #222;
        background: white;
        font-size: 16px;
        transition: 0.3s;
    }

    button:hover {
        background: #ddd;
    }
`;
document.head.appendChild(style);



const app = document.getElementById("app");

const container = document.createElement("div");
container.className = "container";

container.innerHTML = `
    <input type="number" id="num1" placeholder="Birinci ədəd">
    <input type="number" id="num2" placeholder="İkinci ədəd">

    <input type="text" id="result" placeholder="Nəticə" readonly>

    <div class="buttons">
        <button onclick="calc('plus')">Plus</button>
        <button onclick="calc('minus')">Minus</button>
        <button onclick="calc('mult')">Mult</button>
        <button onclick="calc('divide')">Divide</button>
    </div>
`;

app.appendChild(container);



function calc(type) {
    let n1 = parseFloat(document.getElementById("num1").value);
    let n2 = parseFloat(document.getElementById("num2").value);
    let res = document.getElementById("result");

    if (isNaN(n1) || isNaN(n2)) {
        res.value = "Zəhmət olmasa ədədləri düzgün daxil edin!";
        return;
    }

    switch (type) {
        case "plus":
            res.value = n1 + n2;
            break;

        case "minus":
            res.value = n1 - n2;
            break;

        case "mult":
            res.value = n1 * n2;
            break;

        case "divide":
            if (n2 === 0) {
                res.value = "0-a bölmək olmaz!";
            } else {
                res.value = n1 / n2;
            }
            break;

        default:
            res.value = "Xəta!";
    }
}
