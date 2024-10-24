const translations = {
    en: {
        aboutDescription: "Experience the best with us.",
        aboutUs: "About <span>Us</span>",


    },
    az: {
        aboutDescription: "Bizimlə ən yaxşı təcrübəni yaşayın.",
        aboutUs: "Haqqımızda",

    },
    ru: {
        aboutDescription: "Испытайте лучшее с нами.",
        aboutUs: "О <span>нас</span>",
    }
};

const urlParams2 = new URLSearchParams(window.location.search);
let selectedLang2 = urlParams2.get('lang') || 'az';


selectedLang2 = selectedLang2.toLowerCase();

if (selectedLang2 != "az" && selectedLang2 != "ru" && selectedLang2 != "en") {
    selectedLang2 = "az";
}



let translation = translations[selectedLang2]

document.getElementById("aboutUs").innerHTML = translation.aboutUs;
document.getElementById("aboutDescription").innerText = translation.aboutDescription;

