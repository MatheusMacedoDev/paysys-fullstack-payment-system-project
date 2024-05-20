import { z } from 'zod';

const onlyDigits = (text: string): string => text.replace(/[^0-9]/g, '');

export const baseRegisterSchema = z.object({
    userType: z.string(),
    email: z
        .string()
        .min(1, 'O e-mail é obrigatório.')
        .email('Insira um e-mail válido.'),
    phoneNumber: z
        .string()
        .min(15, 'Insira um telefone válido')
        .transform((val) => onlyDigits(val)),
    password: z.string().min(1, 'A senha é obrigatória.'),
    confirmPassword: z.string().min(1, 'A confirmação da senha é obrigatória')
});

export type BaseRegisterData = z.infer<typeof baseRegisterSchema>;

export const commonUserRegisterSchema = baseRegisterSchema.extend({
    name: z.string().min(1, 'O nome é obrigatório.'),
    cpf: z.string().min(1, 'Insira um CPF válido.').transform(onlyDigits)
});

export type CommonUserRegisterData = z.infer<typeof commonUserRegisterSchema>;

export const shopkeeperRegisterSchema = baseRegisterSchema.extend({
    fancyName: z.string().min(1),
    companyName: z.string().min(1),
    cnpj: z.string().min(18).transform(onlyDigits)
});

export type ShopkeeperRegisterData = z.infer<typeof shopkeeperRegisterSchema>;
