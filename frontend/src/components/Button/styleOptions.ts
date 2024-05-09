import { twMerge } from 'tailwind-merge';

export type ButtonColor = 'light' | 'dark';
export type ButtonSize = 'small';

const buttonFixedStyle = 'rounded-full';

const buttonColorStyles = {
    light: 'bg-gradient-to-b from-green-800 to-green-600 text-green-100',
    dark: 'bg-gradient-to-b from-green-400 to-green-200 text-gray-900'
};

const buttonSizeStyles = {
    small: 'w-32 h-10  font-bold text-sm'
};

export function getMergedStyle(
    buttonColor: ButtonColor,
    buttonSize: ButtonSize,
    additionalClassName?: string
) {
    const colorStyle = buttonColorStyles[buttonColor];
    const sizeStyle = buttonSizeStyles[buttonSize];

    const mergedStyle = twMerge(
        buttonFixedStyle,
        colorStyle,
        sizeStyle,
        additionalClassName
    );

    return mergedStyle;
}
