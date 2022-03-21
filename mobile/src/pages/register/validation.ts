import * as Yup from "yup";

export const validationSchema = Yup.object().shape
({
    name: Yup.string().required(),
    username: Yup.string().required(),
    password: Yup.string().required(),
})