document.addEventListener("DOMContentLoaded", function () {
    window.addEventListener('scroll', function () {
        if (window.scrollY > 50) {
            document.getElementById('navbar_top').classList.add('navbar-fixed-top');
            // add padding top to show content behind navbar
            navbar_height = document.querySelector('.navbar').offsetHeight;
            document.body.style.paddingTop = navbar_height + 'px';
        } else {
            document.getElementById('navbar_top').classList.remove('navbar-fixed-top');
            // remove padding top from body
            document.body.style.paddingTop = '0';
        }
    });
});
// DO


let animalsImages = [
    { species: 'cat', image: 'https://cdn.dribbble.com/users/264162/screenshots/16734417/media/282a4351c33576bb1d47b05b59e24a52.png?compress=1&resize=1200x900&vertical=top'},
    { species: 'snail', image: 'https://cdn.dribbble.com/users/383120/screenshots/14976044/media/8b58bc4d6f5a54dce99768869d966a02.png?compress=1&resize=1200x900&vertical=top'},
]
///Tugas------------------
let animals = [
    { name: 'bimo', species: 'cat', kelas: { name: "mamalia" } },
    { name: 'budi', species: 'cat', kelas: { name: "mamalia" } },
    { name: 'nemo', species: 'snail', kelas: { name: "invertebrata" } },
    { name: 'dori', species: 'cat', kelas: { name: "mamalia" } },
    { name: 'simba', species: 'snail', kelas: { name: "invertebrata" } }
];

let OnlyCat = [];
for (var i = 0; i < animals.length; i++) {
    if (animals[i].species == 'cat') {
        OnlyCat.push(animals[i]);
    }
    if (animals[i].species == 'snail') {
        animals[i].kelas.name = "Non-Mamalia";
    }

}
console.log("==========Animals After JS Checking=========");
console.log(animals);
console.log("==========Animals Only Cat=========");
console.log(OnlyCat);
//-------------------end tugas


let listMenu = [];
//each menu with DOM Query Selctor -----
for (var i = 0; i < animals.length; i++) {
 
    if (!listMenu.includes(animals[i].species)) {
        listMenu.push(animals[i].species);
    }
}
let menu = document.querySelector(".menubox .menues");
let htmlList = "";
for (var i = 0; i < listMenu.length; i++) {
    htmlList +=`<li id="box${i}" class="box">${listMenu[i]}</li>`;
}
menu.innerHTML = htmlList;

//Select item menu with DOM Vanilla JS
for (var i = 0; i < listMenu.length; i++) {
    let itemMenu = document.getElementById(`box${i}`);
    itemMenu.addEventListener("click", (e) => {
        console.log(itemMenu.textContent);
//        indexSlected= ;
        menuColorChange(listMenu.findIndex((e) => e == itemMenu.textContent));
        AnimalListChange(itemMenu.textContent);
        ImageChange(itemMenu.textContent);
        
    })

}

//Change data from clicl Acgtions
const menuColorChange = (indexSlected ) => {
    for (var i = 0; i < listMenu.length; i++) {
        let itemMenu = document.getElementById(`box${i}`);
        if (i == indexSlected) {
            itemMenu.style.backgroundColor = "#023E4A";
            itemMenu.style.color = "#ffff";
        } else {
            itemMenu.style.backgroundColor = "#d1e1e0";
            itemMenu.style.color = "#023E4A";
        }
    }
}
const AnimalListChange = (e) => {
    let dataHTML="";
    for (var i = 0; i < animals.length; i++) {
        if (animals[i].species == e) {
            new WOW().init();
            dataHTML += `<li class="wow bounceInUp">${animals[i].name}</li>`;
        }
    }

    //cange HTML with JQUERY
    $('.List').html(dataHTML);
}

const ImageChange = (e) => {
    let dataHtml = "";
    for (var i = 0; i < animalsImages.length; i++) {
        if (animalsImages[i].species == e) {
            new WOW().init();
            dataHTML = `<img src="${animalsImages[i].image}"alt="Lama" />`;
        }
    }

    //cange HTML with JQUERY
    $('.cycleFrame').html(dataHTML);
}

