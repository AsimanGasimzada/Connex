const translations = {
    en: {
        serviceSubtitle: "We offer great services",
        ourServices: "Our <span>Services</span>",

    },
    az: {
        serviceSubtitle: "Biz böyük xidmətlər təklif edirik",
        ourServices: "Xidmətlərimiz",

    },
    ru: {
        serviceSubtitle: "Мы предлагаем отличные услуги",
        ourServices: "Наши <span>услуги</span>",
    }
};

const urlParams2 = new URLSearchParams(window.location.search);
let selectedLang2 = urlParams2.get('lang') || 'az';


selectedLang2 = selectedLang2.toLowerCase();

if (selectedLang2 != "az" && selectedLang2 != "ru" && selectedLang2 != "en") {
    selectedLang2 = "az";
}



let translation = translations[selectedLang2]

document.getElementById("ourServices").innerHTML = translation.ourServices;
document.getElementById("serviceSubtitle").innerText = translation.serviceSubtitle;

