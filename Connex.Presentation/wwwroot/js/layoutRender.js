
const languageData = {
    az: {
        headerHomeText: "Əsas səhifə",
        headerAboutText: "Haqqımızda",
        headerServicesText: "Xidmətlər",
        headerProjectsText: "Layihələr",
        headerContactText: "Əlaqə",

        footerAdressText: "İnfo",
        footerInfoText: "Məlumatlar",
        footerLinkText: "Səhifələr",
        footerHomeText: "Əsas səhifə",
        footerAboutText: "Haqqımızda",
        footerServicesText: "Xidmətlər",
        footerProjectsText: "Layihələr",
        footerContactText: "Əlaqə",
        footerSubscribeText: "Abonəlik",
        footerSubscribePlaceholder: "Dəyişikliklərdən xəbərdar ol.",
        footerAllRights: "Bütün hüquqlar Connex MMC tərəfindən qorunur",
        footerInfo: "Connex şirkəti 2022-ci ildə Aqşin Hüseynov tərəfindən qurulub, müştərilərin xidmətinə verilmişdir.",
        subscribeInputBtn: "Abunə ol"
    },
    en: {
        headerHomeText: "Home",
        headerAboutText: "About Us",
        headerServicesText: "Services",
        headerProjectsText: "Projects",
        headerContactText: "Contact",

        footerAdressText: "Info",
        footerInfoText: "Info",
        footerLinkText: "Pages",
        footerHomeText: "Home",
        footerAboutText: "About Us",
        footerServicesText: "Services",
        footerProjectsText: "Projects",
        footerContactText: "Contact",
        footerSubscribeText: "Subscribe",
        footerSubscribePlaceholder: "Stay updated with our news.",
        footerAllRights: "All rights reserved by Connex LLC",
        footerInfo: "Connex was established in 2022 by Akshin Huseynov and has been serving customers ever since.",
        subscribeInputBtn: "Subscribe"
    },
    ru: {
        headerHomeText: "Главная",
        headerAboutText: "О нас",
        headerServicesText: "Услуги",
        headerProjectsText: "Проекты",
        headerContactText: "Контакт",

        footerAdressText: "Инфо",
        footerInfoText: "Информация",
        footerLinkText: "Страницы",
        footerHomeText: "Главная",
        footerAboutText: "О нас",
        footerServicesText: "Услуги",
        footerProjectsText: "Проекты",
        footerContactText: "Контакт",
        footerSubscribeText: "Подписка",
        footerSubscribePlaceholder: "Оставайтесь в курсе наших новостей.",
        footerAllRights: "Все права защищены компанией Connex LLC.",
        footerInfo: "Компания Connex была основана в 2022 году Акшиным Гусейновым и с тех пор обслуживает клиентов.",
        subscribeInputBtn: "Подписаться"


    }
};

const urlParams = new URLSearchParams(window.location.search);
let selectedLang = urlParams.get('lang') || 'az';

selectedLang = selectedLang.toLowerCase();

if (selectedLang != "az" && selectedLang != "ru" && selectedLang != "en") {
    selectedLang = "az";
}

let selectedLanguageObject = languageData[selectedLang]

document.querySelector('#headerHome').innerText = selectedLanguageObject.headerHomeText;
document.querySelector('#headerAbout').innerText = selectedLanguageObject.headerAboutText;
document.querySelector('#headerServices').innerText = selectedLanguageObject.headerServicesText;
document.querySelector('#headerProjects').innerText = selectedLanguageObject.headerProjectsText;
document.querySelector('#headerContact').innerText = selectedLanguageObject.headerContactText;

document.querySelector('#footerHome').innerText = selectedLanguageObject.footerHomeText;
document.querySelector('#footerAdress').innerText = selectedLanguageObject.footerAdressText;
document.querySelector('#footerInfo').innerText = selectedLanguageObject.footerInfoText;
document.querySelector('#footerInfoArea').innerText = selectedLanguageObject.footerInfo;
document.querySelector('#footerLink').innerText = selectedLanguageObject.footerLinkText;
document.querySelector('#footerAbout').innerText = selectedLanguageObject.footerAboutText;
document.querySelector('#footerServices').innerText = selectedLanguageObject.footerServicesText;
document.querySelector('#footerProjects').innerText = selectedLanguageObject.footerProjectsText;
document.querySelector('#footerContact').innerText = selectedLanguageObject.footerContactText;
document.querySelector('#footerSubscribe').innerText = selectedLanguageObject.footerSubscribeText;
document.querySelector('#footerSubscribePlaceholder').setAttribute('placeholder', selectedLanguageObject.footerSubscribePlaceholder);
document.querySelector('#footerAllRights').innerText = selectedLanguageObject.footerAllRights;
document.querySelector('#SubscribeInputBtn').innerHTML = selectedLanguageObject.subscribeInputBtn;

// Current year for the footer
document.getElementById('displayYear').innerText = new Date().getFullYear();
