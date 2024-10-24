const translations = {
    en: {
        ourProjects: "Our <span>Projects</span>",
        ourProjectsDescription: "We are professionals in our work.",


    },
    az: {
        ourProjects: "Layihələrimiz",
        ourProjectsDescription: "İşimizin peşəkarıyıq.",

    },
    ru: {
        ourProjects: "Наши <span>Проекты</span>",
        ourProjectsDescription: "Мы профессионалы своего дела.",
    }
};

const urlParams2 = new URLSearchParams(window.location.search);
let selectedLang2 = urlParams2.get('lang') || 'az';


selectedLang2 = selectedLang2.toLowerCase();

if (selectedLang2 != "az" && selectedLang2 != "ru" && selectedLang2 != "en") {
    selectedLang2 = "az";
}



let translation = translations[selectedLang2]

document.getElementById("ourProjects").innerHTML = translation.ourProjects;
document.getElementById("ourProjectsDescription").innerHTML = translation.ourProjectsDescription;

