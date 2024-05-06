import globals from 'globals';
import pluginJs from '@eslint/js';
import tseslint from 'typescript-eslint';
import react from 'eslint-plugin-react';
import reactHooks from 'eslint-plugin-react-hooks';

export default [
    {
        settings: {
            react: {
                version: 'detect'
            }
        },
        plugins: {
            react,
            reactHooks
        },
        languageOptions: {
            parserOptions: {
                ecmaFeatures: {
                    jsx: true
                }
            },
            globals: {
                ...globals.browser,
                ...globals.node
            }
        },
        rules: {
            'react/jsx-uses-react': 'off',
            'react/jsx-uses-vars': 'error',
            'reactHooks/rules-of-hooks': 'error',
            'reactHooks/exhaustive-deps': 'warn',
            'react/button-has-type': 'error',
            'react/hook-use-state': 'error'
        }
    },
    pluginJs.configs.recommended,
    ...tseslint.configs.recommended
];
