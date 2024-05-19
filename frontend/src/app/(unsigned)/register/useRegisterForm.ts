import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';

import {
    BaseRegisterData,
    CommonUserRegisterData,
    ShopkeeperRegisterData,
    baseRegisterSchema,
    commonUserRegisterSchema,
    shopkeeperRegisterSchema
} from '@/validations/registerValidations';

import { UserType } from './page';

// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const useRegisterForm = (userType: UserType): any => {
    const baseRegisterForm = useForm<BaseRegisterData>({
        resolver: zodResolver(baseRegisterSchema)
    });

    const commonUserRegisterForm = useForm<CommonUserRegisterData>({
        resolver: zodResolver(commonUserRegisterSchema)
    });

    const shopkeeperRegisterForm = useForm<ShopkeeperRegisterData>({
        resolver: zodResolver(shopkeeperRegisterSchema)
    });

    if (userType === UserType.CommonUser) {
        return commonUserRegisterForm;
    }

    if (userType === UserType.ShopkeeperUser) {
        return shopkeeperRegisterForm;
    }

    return baseRegisterForm;
};
