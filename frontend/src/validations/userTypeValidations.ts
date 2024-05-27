import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

export const userTypeSchema = z.object({
    name: z.string().min(1, 'O nome de usuário é obrigatório.')
});

export type UserTypeData = z.infer<typeof userTypeSchema>;

export const useUserTypeForm = () => {
    return useForm<UserTypeData>({
        resolver: zodResolver(userTypeSchema)
    });
};
