import { IconProp } from '@fortawesome/fontawesome-svg-core';
import type { InputHTMLAttributes } from 'react';
import InputIcon from './InputIcon';
import InputMask from 'react-input-mask';
import { useFormContext } from 'react-hook-form';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    name: string;
    mask?: string;
    icon?: IconProp;
}

export default function Input({ name, mask, icon, ...rest }: InputProps) {
    const { register } = useFormContext();

    const formProps = register(name);

    const inputStyle = `
        border-green-300 border-2 rounded-full
        w-full h-16 lg:h-14 outline-none px-8
        text-xl font-light text-green-300
    `;

    return (
        <div className="relative">
            {mask ? (
                <InputMask
                    mask={mask}
                    className={inputStyle}
                    {...formProps}
                    {...rest}
                />
            ) : (
                <input
                    id={name}
                    className={inputStyle}
                    {...formProps}
                    {...rest}
                />
            )}
            <InputIcon icon={icon} />
        </div>
    );
}
