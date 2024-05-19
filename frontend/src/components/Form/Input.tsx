import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import type { ComponentProps } from 'react';
import { useFormContext } from 'react-hook-form';

interface InputProps extends ComponentProps<'input'> {
    name: string;
    icon?: IconProp;
}

export default function Input({ name, icon, ...rest }: InputProps) {
    const { register } = useFormContext();

    return (
        <div className="relative">
            <input
                id={name}
                className="border-green-300 border-2 rounded-full w-full h-16 lg:h-14 outline-none px-8 text-xl font-light text-green-300"
                {...register(name)}
                {...rest}
            />
            {icon && (
                <div className="w-[50px] lg:w-[42px] h-[50px] lg:h-[42px] rounded-full bg-green-300 absolute right-[9px] top-[7px] flex items-center justify-center">
                    <FontAwesomeIcon
                        className="text-green-950 w-2/5"
                        icon={icon}
                    />
                </div>
            )}
        </div>
    );
}