import { twMerge } from 'tailwind-merge';

interface ButtonProps {
    title: string;
    buttonStyle?: 'light' | 'dark';
    buttonSize?: 'small';
    className?: string;
    actionFn?: () => void;
}

const buttonFixedStyle = 'rounded-full';

const buttonColorStyles = {
    light: 'bg-gradient-to-b from-green-800 to-green-600 text-green-100',
    dark: 'bg-gradient-to-b from-green-400 to-green-200 text-gray-900'
};

const buttonSizeStyles = {
    small: 'w-32 h-10  font-bold text-sm'
};

export default function Button({
    title,
    buttonStyle = 'light',
    buttonSize = 'small',
    className,
    actionFn
}: ButtonProps) {
    const colorStyle = buttonColorStyles[buttonStyle];
    const sizeStyle = buttonSizeStyles[buttonSize];

    const style = twMerge(buttonFixedStyle, colorStyle, sizeStyle, className);

    return (
        <button type="button" onClick={actionFn} className={style}>
            {title}
        </button>
    );
}
