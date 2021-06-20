export interface Mob {
    id: number;
    title: string;
    descr: string;
    imgUrl: string;
    typeName: string;
    typeId: number;
    mAndFDate: Date;
    uploadedBy: string;
    active: boolean;
    link: string;
    langCode: number;
    lang: string;
}
export interface MobType {
    id: number;
    type: string;
}
