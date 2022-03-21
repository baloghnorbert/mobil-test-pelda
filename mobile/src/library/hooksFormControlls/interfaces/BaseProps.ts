import { Control, DeepMap, FieldError } from "react-hook-form";
import { InputType } from "../types/InputType";

export interface IBaseProps
{
    name: string;
    control: any;
    errors?: DeepMap<Record<string, any>, FieldError>;
    disabled?: boolean;
    defaultValue?: InputType; 
}