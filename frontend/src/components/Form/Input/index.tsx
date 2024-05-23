import { IconProp } from '@fortawesome/fontawesome-svg-core';
import type { InputHTMLAttributes } from 'react';
import InputIcon from './InputIcon';
import InputMask from 'react-input-mask';
import { useFormContext } from 'react-hook-form';
import { twMerge } from 'tailwind-merge';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    name: string;
    mask?: string;
    className?: string;
    icon?: IconProp;
}

export default function Input({
    name,
    mask,
    className,
    icon,
    ...rest
}: InputProps) {
    const { register } = useFormContext();

    const formProps = register(name);

    const inputDefaultStyle = `
        border-green-300 border-2 rounded-full
        w-full h-16 lg:h-14 outline-none px-8
        text-xl font-light text-green-300
    `;

    const inputStyle = twMerge(inputDefaultStyle, className);

    return (
        <div className="relative flex flex-1">
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
