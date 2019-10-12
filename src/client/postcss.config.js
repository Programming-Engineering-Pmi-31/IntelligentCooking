module.exports = {
    plugins: [
        require('autoprefixer'),
        require('cssnano')({
            preset: [
                'default',
                {
                    discartComments: {
                        removeAll: true,
                    },
                },
            ],
        }),
        require('css-mqpacker'),
    ],
};
