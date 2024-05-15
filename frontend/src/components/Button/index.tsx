import type { ComponentProps } from 'react';

import { ButtonColor, ButtonSize, getMergedStyle } from './styleOptions';

interface ButtonProps extends ComponentProps<'button'> {
    title: string;
    buttonColor?: ButtonColor;
    buttonSize?: ButtonSize;
    className?: string;
    isSubmitButton?: boolean;
}

export default function Button({
    title,
    buttonColor = 'light',
    buttonSize = 'small',
    isSubmitButton = false,
    className,
    ...rest
}: ButtonProps) {
    const style = getMergedStyle(buttonColor, buttonSize, className);

    return (
        <button
            type={isSubmitButton ? 'submit' : 'button'}
            className={style}
            {...rest}
        >
            {title}
        </button>
    );
}
