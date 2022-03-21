import * as Yup from "yup";

export const validationSchema = Yup.object().shape
({
    name: Yup.string().required(),
    imageLink: Yup.string().required(),
    club: Yup.string().required(),
    birthday: Yup.date().required(),
    weight: Yup.number().required().min(0),
    height: Yup.number().required().min(0),
    description: Yup.string().required(),
    positionId: Yup.number().required()
})