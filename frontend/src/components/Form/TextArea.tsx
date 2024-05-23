import { InputHTMLAttributes } from 'react';
import { useFormContext } from 'react-hook-form';
import { twMerge } from 'tailwind-merge';

interface TextAreaProps extends InputHTMLAttributes<HTMLTextAreaElement> {
    name: string;
    className?: string;
}

export default function TextArea({ name, className, ...props }: TextAreaProps) {
    const { register } = useFormContext();

    const textAreaDefaultStyle = `
        border-green-300 border-2 rounded-3xl
        w-full min-h-16 max-h-64 outline-none px-8 py-4
        text-xl font-light text-green-300
    `;

    const textAreaStyle = twMerge(textAreaDefaultStyle, className);

    return (
        <textarea
            id={name}
            className={textAreaStyle}
            {...register(name)}
            {...props}
        />
    );
}
