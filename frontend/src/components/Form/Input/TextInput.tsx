import { ComponentProps } from 'react';
import { useFormContext } from 'react-hook-form';

interface TextInputProps extends ComponentProps<'input'> {
    name: string;
}

export default function TextInput({ name, ...rest }: TextInputProps) {
    const { register } = useFormContext();

    return (
        <input
            id={name}
            className="border-green-300 border-2 rounded-full w-full h-16 lg:h-14 outline-none px-8 text-xl font-light text-green-300"
            {...register(name)}
            {...rest}
        />
    );
}
