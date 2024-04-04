import * as yup from 'yup';

export const Step1FormSchema = yup.object().shape({
  idsTags: yup
    .array()
    .of(yup
      .number()
      .required())
    .min(1, "Selecione pelo menos uma tag!")
    .required("Selecione pelo menos uma tag!"),
  idDepartamento: yup
    .number()
    .required("Selecione algum departamento!"),
});
