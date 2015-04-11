using System.ComponentModel.DataAnnotations;

namespace OnePeek.Entities
{
  public enum StoreCultureType
  {
    /// <summary>
    /// Undefined culture, will throw in API
    /// </summary>
    Unknown,
    /// <summary>
    /// Angola (Português - Portugal)
    /// </summary>
    [Display(Name = "Angola (Português - Portugal)")]
    PT_AO,
    /// <summary>
    /// Argentina (Español)
    /// </summary>
    [Display(Name = "Argentina (Español)")]
    ES_AR,
    /// <summary>
    /// Armenia (English)
    /// </summary>
    [Display(Name = "Armenia (English)")]
    EN_AM,
    /// <summary>
    /// Australia (English)
    /// </summary>
    [Display(Name = "Australia (English)")]
    EN_AU,
    /// <summary>
    /// Azərbaycan (Azərbaycan)
    /// </summary>
    [Display(Name = "Azərbaycan (Azərbaycan)")]
    AZ_LATN_AZ,
    /// <summary>
    /// Bangladesh (English)
    /// </summary>
    [Display(Name = "Bangladesh (English)")]
    EN_BD,
    /// <summary>
    /// België (Nederlands)
    /// </summary>
    [Display(Name = "België (Nederlands)")]
    NL_BE,
    /// <summary>
    /// Belgique (français)
    /// </summary>
    [Display(Name = "Belgique (français)")]
    FR_BE,
    /// <summary>
    /// Bénin (français)
    /// </summary>
    [Display(Name = "Bénin (français)")]
    FR_BJ,
    /// <summary>
    /// Bolivia (Español)
    /// </summary>
    [Display(Name = "Bolivia (Español)")]
    ES_BO,
    /// <summary>
    /// Brasil (Português - Brasil)
    /// </summary>
    [Display(Name = "Brasil (Português - Brasil)")]
    PT_BR,
    /// <summary>
    /// Burkina Faso (français)
    /// </summary>
    [Display(Name = "Burkina Faso (français)")]
    FR_BF,
    /// <summary>
    /// Burundi (français)
    /// </summary>
    [Display(Name = "Burundi (français)")]
    FR_BI,
    /// <summary>
    /// Cameroon (English)
    /// </summary>
    [Display(Name = "Cameroon (English)")]
    EN_CM,
    /// <summary>
    /// Canada (English)
    /// </summary>
    [Display(Name = "Canada (English)")]
    EN_CA,
    /// <summary>
    /// Canada (français)
    /// </summary>
    [Display(Name = "Canada (français)")]
    FR_CA,
    /// <summary>
    /// Česká republika (čeština)
    /// </summary>
    [Display(Name = "Česká republika (čeština)")]
    CS_CZ,
    /// <summary>
    /// Chile (Español)
    /// </summary>
    [Display(Name = "Chile (Español)")]
    ES_CL,
    /// <summary>
    /// Colombia (Español)
    /// </summary>
    [Display(Name = "Colombia (Español)")]
    ES_CO,
    /// <summary>
    /// Congo (français)
    /// </summary>
    [Display(Name = "Congo (français)")]
    FR_CD,
    /// <summary>
    /// Costa Rica (Español)
    /// </summary>
    [Display(Name = "Costa Rica (Español)")]
    ES_CR,
    /// <summary>
    /// Côte d'Ivoire (français)
    /// </summary>
    [Display(Name = "Côte d'Ivoire (français)")]
    FR_CI,
    /// <summary>
    /// Danmark (dansk)
    /// </summary>
    [Display(Name = "Danmark (dansk)")]
    DA_DK,
    /// <summary>
    /// Deutschland (Deutsch)
    /// </summary>
    [Display(Name = "Deutschland (Deutsch)")]
    DE_DE,
    /// <summary>
    /// Ecuador (Español)
    /// </summary>
    [Display(Name = "Ecuador (Español)")]
    ES_EC,
    /// <summary>
    /// Eesti (eesti)
    /// </summary>
    [Display(Name = "Eesti (eesti)")]
    ET_EE,
    /// <summary>
    /// El Salvador (Español)
    /// </summary>
    [Display(Name = "El Salvador (Español)")]
    ES_SV,
    /// <summary>
    /// España (Español)
    /// </summary>
    [Display(Name = "España (Español)")]
    ES_ES,
    /// <summary>
    /// Espanya (Català)
    /// </summary>
    [Display(Name = "Espanya (Català)")]
    CA_ES,
    /// <summary>
    /// France (français)
    /// </summary>
    [Display(Name = "France (français)")]
    FR_FR,
    /// <summary>
    /// Ghana (English)
    /// </summary>
    [Display(Name = "Ghana (English)")]
    EN_GH,
    /// <summary>
    /// Guatemala (Español)
    /// </summary>
    [Display(Name = "Guatemala (Español)")]
    ES_GT,
    /// <summary>
    /// Guinée (français)
    /// </summary>
    [Display(Name = "Guinée (français)")]
    FR_GN,
    /// <summary>
    /// Haïti (français)
    /// </summary>
    [Display(Name = "Haïti (français)")]
    FR_HT,
    /// <summary>
    /// Honduras (Español)
    /// </summary>
    [Display(Name = "Honduras (Español)")]
    ES_HN,
    /// <summary>
    /// Hong Kong (English)
    /// </summary>
    [Display(Name = "Hong Kong (English)")]
    EN_HK,
    /// <summary>
    /// Hrvatska (hrvatski)
    /// </summary>
    [Display(Name = "Hrvatska (hrvatski)")]
    HR_HR,
    /// <summary>
    /// Iceland (English)
    /// </summary>
    [Display(Name = "Iceland (English)")]
    IS_IS,
    /// <summary>
    /// India (English)
    /// </summary>
    [Display(Name = "India (English)")]
    EN_IN,
    /// <summary>
    /// Indonesia (Bahasa Indonesia)
    /// </summary>
    [Display(Name = "Indonesia (Bahasa Indonesia)")]
    ID_ID,
    /// <summary>
    /// Ireland (English)
    /// </summary>
    [Display(Name = "Ireland (English)")]
    EN_IE,
    /// <summary>
    /// Italia (italiano)
    /// </summary>
    [Display(Name = "Italia (italiano)")]
    IT_IT,
    /// <summary>
    /// Kenya (English)
    /// </summary>
    [Display(Name = "Kenya (English)")]
    EN_KE,
    /// <summary>
    /// Kuwait (English)
    /// </summary>
    [Display(Name = "Kuwait (English)")]
    EN_KW,
    /// <summary>
    /// Latvija (latviešu)
    /// </summary>
    [Display(Name = "Latvija (latviešu)")]
    LV_LV,
    /// <summary>
    /// Liechtenstein (Deutsch)
    /// </summary>
    [Display(Name = "Liechtenstein (Deutsch)")]
    DE_LI,
    /// <summary>
    /// Lietuva (lietuvių)
    /// </summary>
    [Display(Name = "Lietuva (lietuvių)")]
    LT_LT,
    /// <summary>
    /// Madagascar (français)
    /// </summary>
    [Display(Name = "Madagascar (français)")]
    FR_MG,
    /// <summary>
    /// Magyarország (magyar)
    /// </summary>
    [Display(Name = "Magyarország (magyar)")]
    HU_HU,
    /// <summary>
    /// Malawi (English)
    /// </summary>
    [Display(Name = "Malawi (English)")]
    EN_MW,
    /// <summary>
    /// Malaysia (Bahasa Melayu)
    /// </summary>
    [Display(Name = "Malaysia (Bahasa Melayu)")]
    MS_MY,
    /// <summary>
    /// Malaysia (English)
    /// </summary>
    [Display(Name = "Malaysia (English)")]
    EN_MY,
    /// <summary>
    /// Mali (français)
    /// </summary>
    [Display(Name = "Mali (français)")]
    FR_ML,
    /// <summary>
    /// México (Español)
    /// </summary>
    [Display(Name = "México (Español)")]
    ES_MX,
    /// <summary>
    /// Moçambique (Português - Portugal)
    /// </summary>
    [Display(Name = "Moçambique (Português - Portugal)")]
    PT_MZ,
    /// <summary>
    /// Nederland (Nederlands)
    /// </summary>
    [Display(Name = "Nederland (Nederlands)")]
    NL_NL,
    /// <summary>
    /// New Zealand (English)
    /// </summary>
    [Display(Name = "New Zealand (English)")]
    EN_NZ,
    /// <summary>
    /// Nicaragua (Español)
    /// </summary>
    [Display(Name = "Nicaragua (Español)")]
    ES_NI,
    /// <summary>
    /// Niger (français)
    /// </summary>
    [Display(Name = "Niger (français)")]
    FR_NE,
    /// <summary>
    /// Nigeria (English)
    /// </summary>
    [Display(Name = "Nigeria (English)")]
    EN_NG,
    /// <summary>
    /// Norge (norsk)
    /// </summary>
    [Display(Name = "Norge (norsk)")]
    NB_NO,
    /// <summary>
    /// Österreich (Deutsch)
    /// </summary>
    [Display(Name = "Österreich (Deutsch)")]
    DE_AT,
    /// <summary>
    /// O'zbekiston (O'zbekcha)
    /// </summary>
    [Display(Name = "O'zbekiston (O'zbekcha)")]
    UZ_LATN_UZ,
    /// <summary>
    /// Pakistan (English)
    /// </summary>
    [Display(Name = "Pakistan (English)")]
    EN_PK,
    /// <summary>
    /// Paraguay (Español)
    /// </summary>
    [Display(Name = "Paraguay (Español)")]
    ES_PY,
    /// <summary>
    /// Perú (Español)
    /// </summary>
    [Display(Name = "Perú (Español)")]
    ES_PE,
    /// <summary>
    /// Philippines (English)
    /// </summary>
    [Display(Name = "Philippines (English)")]
    EN_PH,
    /// <summary>
    /// Pilipinas (Filipino)
    /// </summary>
    [Display(Name = "Pilipinas (Filipino)")]
    FIL_PH,
    /// <summary>
    /// Polska (polski)
    /// </summary>
    [Display(Name = "Polska (polski)")]
    PL_PL,
    /// <summary>
    /// Portugal (Português - Portugal)
    /// </summary>
    [Display(Name = "Portugal (Português - Portugal)")]
    PT_PT,
    /// <summary>
    /// República Dominicana (Español)
    /// </summary>
    [Display(Name = "República Dominicana (Español)")]
    ES_DO,
    /// <summary>
    /// România (Română)
    /// </summary>
    [Display(Name = "România (Română)")]
    RO_RO,
    /// <summary>
    /// Rwanda (français)
    /// </summary>
    [Display(Name = "Rwanda (français)")]
    FR_RW,
    /// <summary>
    /// Schweiz (Deutsch)
    /// </summary>
    [Display(Name = "Schweiz (Deutsch)")]
    DE_CH,
    /// <summary>
    /// Sénégal (français)
    /// </summary>
    [Display(Name = "Sénégal (français)")]
    FR_SN,
    /// <summary>
    /// Shqipëria (shqip)
    /// </summary>
    [Display(Name = "Shqipëria (shqip)")]
    SQ_AL,
    /// <summary>
    /// Sierra Leone (English)
    /// </summary>
    [Display(Name = "Sierra Leone (English)")]
    EN_SL,
    /// <summary>
    /// Singapore (English)
    /// </summary>
    [Display(Name = "Singapore (English)")]
    EN_SG,
    /// <summary>
    /// Slovenija (slovenščina)
    /// </summary>
    [Display(Name = "Slovenija (slovenščina)")]
    SL_SI,
    /// <summary>
    /// Slovensko (slovenčina)
    /// </summary>
    [Display(Name = "Slovensko (slovenčina)")]
    SK_SK,
    /// <summary>
    /// Somalia (English)
    /// </summary>
    [Display(Name = "Somalia (English)")]
    EN_SO,
    /// <summary>
    /// South Africa (English)
    /// </summary>
    [Display(Name = "South Africa (English)")]
    EN_ZA,
    /// <summary>
    /// Srbija (srpski)
    /// </summary>
    [Display(Name = "Srbija (srpski)")]
    SR_LATN_CS,
    /// <summary>
    /// Suisse (français)
    /// </summary>
    [Display(Name = "Suisse (français)")]
    FR_CH,
    /// <summary>
    /// Suomi (suomi)
    /// </summary>
    [Display(Name = "Suomi (suomi)")]
    FI_FI,
    /// <summary>
    /// Sverige (svenska)
    /// </summary>
    [Display(Name = "Sverige (svenska)")]
    SV_SE,
    /// <summary>
    /// Svizzera (italiano)
    /// </summary>
    [Display(Name = "Svizzera (italiano)")]
    IT_CH,
    /// <summary>
    /// Tanzania (English)
    /// </summary>
    [Display(Name = "Tanzania (English)")]
    EN_TZ,
    /// <summary>
    /// Tchad (français)
    /// </summary>
    [Display(Name = "Tchad (français)")]
    FR_TD,
    /// <summary>
    /// Togo (français)
    /// </summary>
    [Display(Name = "Togo (français)")]
    FR_TG,
    /// <summary>
    /// Türkiye (Türkçe)
    /// </summary>
    [Display(Name = "Türkiye (Türkçe)")]
    TR_TR,
    /// <summary>
    /// Uganda (English)
    /// </summary>
    [Display(Name = "Uganda (English)")]
    EN_UG,
    /// <summary>
    /// United Kingdom (English)
    /// </summary>
    [Display(Name = "United Kingdom (English)")]
    EN_GB,
    /// <summary>
    /// United States (English)
    /// </summary>
    [Display(Name = "United States (English)")]
    EN_US,
    /// <summary>
    /// Venezuela (Español)
    /// </summary>
    [Display(Name = "Venezuela (Español)")]
    ES_VE,
    /// <summary>
    /// Việt Nam (Tiếng Việt)
    /// </summary>
    [Display(Name = "Việt Nam (Tiếng Việt)")]
    VI_VN,
    /// <summary>
    /// Zambia (English)
    /// </summary>
    [Display(Name = "Zambia (English)")]
    EN_ZM,
    /// <summary>
    /// Zimbabwe (English)
    /// </summary>
    [Display(Name = "Zimbabwe (English)")]
    EN_ZW,
    /// <summary>
    /// Ελλάδα (Ελληνικά)
    /// </summary>
    [Display(Name = "Ελλάδα (Ελληνικά)")]
    EL_GR,
    /// <summary>
    /// Беларусь (Беларуская)
    /// </summary>
    [Display(Name = "Беларусь (Беларуская)")]
    BE_BY,
    /// <summary>
    /// България (български)
    /// </summary>
    [Display(Name = "България (български)")]
    BG_BG,
    /// <summary>
    /// Қазақстан (Қазақ)
    /// </summary>
    [Display(Name = "Қазақстан (Қазақ)")]
    KK_KZ,
    /// <summary>
    /// Македонија, ПЈР (македонски)
    /// </summary>
    [Display(Name = "Македонија, ПЈР (македонски)")]
    MK_MK,
    /// <summary>
    /// Россия (Русский)
    /// </summary>
    [Display(Name = "Россия (Русский)")]
    RU_RU,
    /// <summary>
    /// Тоҷикистон (Русский)
    /// </summary>
    [Display(Name = "Тоҷикистон (Русский)")]
    RU_TJ,
    /// <summary>
    /// Туркменистан (Русский)
    /// </summary>
    [Display(Name = "Туркменистан (Русский)")]
    RU_TM,
    /// <summary>
    /// Україна (українська)
    /// </summary>
    [Display(Name = "Україна (українська)")]
    UK_UA,
    /// <summary>
    /// ישראל (עברית)
    /// </summary>
    [Display(Name = "ישראל (עברית)")]
    HE_IL,
    /// <summary>
    /// الأردن (العربية)
    /// </summary>
    [Display(Name = "الأردن (العربية)")]
    AR_JO,
    /// <summary>
    /// الإمارات العربية المتحدة (العربية)
    /// </summary>
    [Display(Name = "الإمارات العربية المتحدة (العربية)")]
    AR_AE,
    /// <summary>
    /// البحرين (العربية)
    /// </summary>
    [Display(Name = "البحرين (العربية)")]
    AR_BH,
    /// <summary>
    /// الجزائر (العربية)
    /// </summary>
    [Display(Name = "الجزائر (العربية)")]
    AR_DZ,
    /// <summary>
    /// العراق (العربية)
    /// </summary>
    [Display(Name = "العراق (العربية)")]
    AR_IQ,
    /// <summary>
    /// الكويت (العربية)
    /// </summary>
    [Display(Name = "الكويت (العربية)")]
    AR_KW,
    /// <summary>
    /// المغرب (العربية)
    /// </summary>
    [Display(Name = "المغرب (العربية)")]
    AR_MA,
    /// <summary>
    /// المملكة العربية السعودية (العربية)
    /// </summary>
    [Display(Name = "المملكة العربية السعودية (العربية)")]
    AR_SA,
    /// <summary>
    /// اليمن (العربية)
    /// </summary>
    [Display(Name = "اليمن (العربية)")]
    AR_YE,
    /// <summary>
    /// تونس (العربية)
    /// </summary>
    [Display(Name = "تونس (العربية)")]
    AR_TN,
    /// <summary>
    /// عمان (العربية)
    /// </summary>
    [Display(Name = "عمان (العربية)")]
    AR_OM,
    /// <summary>
    /// قطر (العربية)
    /// </summary>
    [Display(Name = "قطر (العربية)")]
    AR_QA,
    /// <summary>
    /// مصر (العربية)
    /// </summary>
    [Display(Name = "مصر (العربية)")]
    AR_EG,
    /// <summary>
    /// भारत (हिन्दी)
    /// </summary>
    [Display(Name = "भारत (हिन्दी)")]
    HI_IN,
    /// <summary>
    /// ไทย (ไทย)
    /// </summary>
    [Display(Name = "ไทย (ไทย)")]
    TH_TH,
    /// <summary>
    /// 대한민국 (한국어)
    /// </summary>
    [Display(Name = "대한민국 (한국어)")]
    KO_KR,
    /// <summary>
    /// 中国 (简体中文)
    /// </summary>
    [Display(Name = "中国 (简体中文)")]
    ZH_CN,
    /// <summary>
    /// 台灣 (繁體中文)
    /// </summary>
    [Display(Name = "台灣 (繁體中文)")]
    ZH_TW,
    /// <summary>
    /// 日本 (日本語)
    /// </summary>
    [Display(Name = "日本 (日本語)")]
    JA_JP,
    /// <summary>
    /// 香港 (繁體中文)
    /// </summary>
    [Display(Name = "香港 (繁體中文)")]
    ZH_HK
  }
}
