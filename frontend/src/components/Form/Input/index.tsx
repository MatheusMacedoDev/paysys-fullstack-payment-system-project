import { IconProp } from '@fortawesome/fontawesome-svg-core';
import type { ComponentProps } from 'react';
import InputIcon from './InputIcon';
import TextInput from './TextInput';

interface InputProps extends ComponentProps<'input'> {
    name: string;
    icon?: IconProp;
}

export default function Input({ name, icon, ...rest }: InputProps) {
    return (
        <div className="relative">
            <TextInput name={name} {...rest} />
            <InputIcon icon={icon} />
        </div>
    );
}
