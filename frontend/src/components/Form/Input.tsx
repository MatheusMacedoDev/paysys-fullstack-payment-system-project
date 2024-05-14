import type { ComponentProps } from 'react';

interface InputProps extends ComponentProps<'input'> {}

export default function Input({ ...rest }: InputProps) {
    return (
        <input
            {...rest}
            className="border-green-300 border-2 rounded-full w-full h-16 outline-none px-8 text-xl font-light text-green-300"
        />
    );
}
