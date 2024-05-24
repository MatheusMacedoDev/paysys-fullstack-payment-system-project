import { ReactNode } from 'react';
import Button from '../Button';
import type { ComponentProps } from 'react';
import { twMerge } from 'tailwind-merge';

interface ContainerProps extends ComponentProps<'form'> {
    children: ReactNode;
    sendButtonTitle: string;
    className?: string;
}

export default function Container({
    children,
    sendButtonTitle,
    className,
    ...rest
}: ContainerProps) {
    const containerDefaultStyle =
        'w-full lg:w-3/5 xl:w-2/5 px-8 lg:px-14 xl:px-16 py-12 lg:py-16 xl:py-20 lg:shadow-[3px_3px_10px_0_rgba(0,0,0,0.2)] lg:rounded-xl bg-gray-900 flex flex-col items-center';
    const containerStyle = twMerge(containerDefaultStyle, className);

    return (
        <form className={containerStyle} {...rest}>
            {children}
            <Button
                title={sendButtonTitle}
                buttonColor="light"
                buttonSize="big"
                isSubmitButton={true}
            />
        </form>
    );
}
